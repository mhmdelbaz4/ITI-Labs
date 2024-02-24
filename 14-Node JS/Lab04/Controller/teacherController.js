exports.getAllTeachers = (req,res,next)=>{
    res.status(200).json({data:"get all teachers"});
}

exports.insertTeacher = (req,res,next)=>{
    res.status(201).json({data:"insert teacher"});
}

exports.updateTeacher = (req,res,next)=>{
    res.status(200).json({data:"update teacher"});
}

exports.deleteTeacher = (req,res,next)=>{
    res.status(200).json({data:"delete teacher"});
}

exports.getTeacherByID = (req,res,next)=>{
    res.json({data:"get teacher by id"})
}

exports.getAllSupervisors = (req,res,next)=>{
    res.json({data:"get all supervisors"});
}