const express = require("express");
const router = express.Router();
const child = require("../Controller/childController");


router.route("/child")
            .get(child.getAllChildren)
            .post(express.json(),child.insertChild)
            .patch(child.updateChild)
            .delete(child.deleteChild);
            
router.route("/child/:id",child.getChildById);


module.exports= router;