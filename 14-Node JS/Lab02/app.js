const express = require("express");
const morgan = require("morgan");
const cors = require('cors');
const router = require("./Route/studentRoute");
const server = express();


server.listen(8080,() =>{
    console.log("server is listening.........");
});

server.use(morgan(':method :url'));
server.use(cors());
// Middlewares
///////////////////////
// 1........................ Logging Middleware
server.use((request,response,next) =>{
    console.log("Logging");
    next();
});

// 2....................... Authorization Middleware
server.use((request,response,next) =>{
    console.log("Authorization"); 
    if(true)
    {
        console.log("user is authorized"); 
    }else{
        next(new Error("Not Authorized"));
    }
    next();
});

// new one 
// server.use((request,response,next) =>{
//     console.log(request.url);
//     console.log(request.method);
//     next();
// })


// 3......................... Routers
server.use(router)

// 4........................ NotFound
server.use((request,response) =>{
    console.log("NotFound Middleware");
    response.status(404).json({message : "Not Found"})
});

// 5........................ Error handling
server.use((error ,request,response,next) =>{
    console.log("error Middleware");
    response.status(500).json({message :error.message +""});
}); 