const express = require("express");
const morgan = require("morgan");
const studentRoute = require("./Route/studentRoute");
const teacherRoute = require("./Route/teacherRoute");
const classRoute = require("./Route/classRoute");

const server = express();

server.listen(8080,()=>{
    console.log("server is listening......");
});

server.use(morgan(':method :url'));

server.use(express.json());

// routers
server.use(studentRoute);
server.use(teacherRoute);
server.use(classRoute)

server.use((req,res,next)=>{
    res.status(404).json({message:"NotFound"})
});

// Error Middleware
server.use((error,req,res,next) =>{
   res.status(500).json({message:error.message+""}); 
});
