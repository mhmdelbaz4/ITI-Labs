exports.getAllStudents = (req,res,next)=>{
    res.status(200).json({data:"get all students"});
}

exports.insertStudent = (req,res,next)=>{
    res.status(201).json({data:"insert student"});
}

exports.updateStudent = (req,res,next)=>{
    res.status(200).json({data:"update Student"});
}

exports.deleteStudent =  (req,res,next)=>{
    res.status(200).json({data:"delete Student"});
}