exports.getAllClasses = (req,res,error)=>{
    res.status(200).json({data:"get all classes"});
}

exports.getClassById = (req,res,error)=>{
    res.status(200).json({data:"get class By ID"});
}

exports.insertClass = (req,res,error)=>{
    res.status(201).json({data:"insert class"});
}

exports.updateClass = (req,res,error)=>{
    res.status(200).json({data:"update class"});
}

exports.deleteClass = (req,res,error)=>{
    res.status(200).json({data:"delete class"});
}

exports.getClassChildren = (req,res,error)=>{
    res.status(200).json({data:"get children of the class"});
}

exports.getClassSupervisor = (req,res,error)=>{
    res.status(200).json({data:"get class supervisor"});
}