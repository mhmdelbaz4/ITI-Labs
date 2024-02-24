exports.getAllChildren = (req,res,next)=>{
    res.status(200).json({data:"get all children"}); 
}

exports.getChildById = (req,res,next)=>{
    res.status(200).json({data:"get child by id"}); 
}

exports.insertChild = (req,res,next)=>{
    res.status(201).json({data:"insert child"});
}

exports.updateChild = (req,res,next)=>{
    res.status(200).json({data:"update child"});
}

exports.deleteChild = (req,res,next)=>{
    res.status(200).json({data:"delete child"});
}