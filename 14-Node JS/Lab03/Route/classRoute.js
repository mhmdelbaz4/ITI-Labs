const express = require("express");
const router = express.router();
const classController = require("./../Controller/classController");


router.match("class")
    .get(classController.getAllClasses)
    .post(classController.insertClass)
    .patch(classController.updateClass)
    .delete(classController.deleteClass);

router.get("/class/:id",classController.getClassById);
router.get("/class/child/:id",classController.getClassChildren);
router.get("/class/teacher/:id",classController.getClassSupervisor);
