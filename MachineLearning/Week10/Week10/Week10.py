import os
import re
from shutil import copyfile
import argparse
import math
import random
from pathlib import Path
from typing import List
import Coco

import numpy as np
from PIL import Image
from Coco import Coco, CocoAnnotation, CocoCategory, CocoImage
import json
from tqdm import tqdm

# type check when save json files
class NumpyEncoder(json.JSONEncoder):
    def default(self, obj):
        if isinstance(obj, np.integer):
            return int(obj)
        elif isinstance(obj, np.floating):
            return float(obj)
        elif isinstance(obj, np.ndarray):
            return obj.tolist()
        else:
            return super(NumpyEncoder, self).default(obj)

def save_json(dest, cocoJson, filename):
    save_path = str(Path(dest) / filename)
    with open(save_path, "w", encoding="utf-8") as outfile:
        json.dump(cocoJson, outfile, separators=(",", ":"), cls=NumpyEncoder)

def open_json(json_path):
    with open(json_path) as json_file:
        data = json.load(json_file)
    return data

def create_coco_anotations(image_anotations, saveFilename, numberOfImages, savedest):
    # init coco object
    coco = Coco()
    category_ind = 0
    for i in range(numberOfImages):
        idx = random.randint(0, len(image_anotations) - 1)
        json_path = image_anotations[idx]

        data = open_json(json_path)

        temp_img_path = json_path.replace('\\', '/')
        temp_img_path = temp_img_path.rpartition('/');
        image_path = str(Path(temp_img_path[0]) / data["imagePath"])
        
        width, height = Image.open(image_path).size
        # init coco image
        coco_image = CocoImage(file_name=data["imagePath"], height=height, width=width)

        # iterate over annotations
        for shape in data["shapes"]:
            # set category name and id
            category_name = shape["label"]
            category_id = None
            for (
                    coco_category_id,
                    coco_category_name,
            ) in coco.category_mapping.items():
                if category_name == coco_category_name:
                    category_id = coco_category_id
                    break
            # add category if not present
            if category_id is None:
                category_id = category_ind
                coco.add_category(CocoCategory(id=category_id, name=category_name))
                category_ind += 1
            # parse bbox/segmentation
            if shape["shape_type"] == "rectangle":
                x1 = shape["points"][0][0]
                y1 = shape["points"][0][1]
                x2 = shape["points"][1][0]
                y2 = shape["points"][1][1]
                coco_annotation = CocoAnnotation(
                    bbox=[x1, y1, x2 - x1, y2 - y1],
                    category_id=category_id,
                    category_name=category_name,
                )
            elif shape["shape_type"] == "polygon":
                segmentation = [np.asarray(shape["points"]).flatten().tolist()]
                coco_annotation = CocoAnnotation(
                    segmentation=segmentation,
                    category_id=category_id,
                    category_name=category_name,
                )
            else:
                raise NotImplementedError(
                    f'shape_type={shape["shape_type"]} not supported.'
                )
            coco_image.add_annotation(coco_annotation)

        coco.add_image(coco_image)

        # export as json
        save_json(savedest, coco.json, saveFilename)
        
        image_anotations.remove(image_anotations[idx])

    return image_anotations

def generate_coco_json(source, dest, ratio, limitFolders = []):
    source = source.replace('\\', '/')
    dest = dest.replace('\\', '/')
    train_file = os.path.join(dest, 'train.json')
    val_file = os.path.join(dest, 'val.json')

    if not os.path.exists(dest):
        os.makedirs(dest)

    image_anotations = []
    if len(limitFolders) == 0:    
        for root, dirs, files in os.walk(source):
            for filename in files:
                if re.search(r'([a-zA-Z0-9\s_\\.\-\(\):])+(.json)$', filename):
                    image_anotations.append(os.path.join(root, filename))

    else:
        for folder in limitFolders:
            for filename in os.listdir(os.path.join(source,folder)):
                if re.search(r'([a-zA-Z0-9\s_\\.\-\(\):])+(.json)$', filename):
                    image_anotations.append(os.path.join(source,folder,filename))

    print(image_anotations)
    num_image_anotations = len(image_anotations)
    num_val_image_anotations = math.ceil(ratio * num_image_anotations)
    
    print('val: ' + str(num_val_image_anotations))
    image_anotations = create_coco_anotations(image_anotations, 'val.json', num_val_image_anotations, dest)
    print('Train: ' + str(len(image_anotations)))
    image_anotations = create_coco_anotations(image_anotations, 'train.json', len(image_anotations), dest)
    print("Completed! " + str(num_image_anotations))

# Restricted to only take subfolders
generate_coco_json(os.path.join('Images'), os.path.join('Exercise', 'Output', 'FunnyProject'), 0.25, ["Humans","Pigs"])
# Without limited folders take a parent folder and including all child folders
generate_coco_json(os.path.join('Images'), os.path.join('Exercise', 'Output', 'FunnyProject'), 0.25)