const express = require("express");
const router = express.router();
const studentController = require("./../Controller/studentsController");

router.route("/students")
    .get(studentController.getAllStudents)
    .post(studentController.insertStudent)
    .patch(studentController.updateStudent)
    .delete(studentController.deleteStudent);

module.exports = router;