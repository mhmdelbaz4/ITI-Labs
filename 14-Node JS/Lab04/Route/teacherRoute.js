const express = require("express");
const router = express.router();
const teacherController = require("./../Controller/teacherController");


router.route("/teachers")
    .get(teacherController.getAllTeachers)
    .post(teacherController.insertTeacher)
    .patch(teacherController.updateTeacher)
    .delete(teacherController.deleteTeacher);

router.get("/teachers/:id" ,teacherController.getTeacherByID);

router.get("teachers/supervisors" ,teacherController.getAllSupervisors);


module.exports = router;