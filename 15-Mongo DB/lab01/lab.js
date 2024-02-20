//1.install mongo
//2.open shell
> mongosh
//help 
>help
//3.current db
> db
// available dbs
> show dbs
//4.facebook db
>use facebook
//5.posts collection
>db.createCollection("posts")
//6. users
>db.createCollection("users",{
    capped:true,
    size:5242880,
    max:10,
    validator:{$and:[{username:{$type:"string"}},{email:{$regex:".*@gmail.com$"}}]}
})

//7.Insert 20 posts.
>db.posts.insertMany([{
    post_text: "Hello World",
    images: ["image1.jpeg", "image2.jpeg"],
    likes: 100,
    comments: ["nice", "well done"],
    Datetime: new Date(),
    owner: "ahmed",
    live: true
},{
    post_text: "Hello World",
    images: ["image1.jpeg", "image2.jpeg"],
    likes: 50,
    comments: ["nice", "well done"],
    Datetime: new Date(),
    owner: "sayed",
    live: true
},{
    post_text: "Hello World",
    images: ["image1.jpeg", "image2.jpeg"],
    likes: 10,
    comments: ["nice", "done"],
    Datetime: new Date(),
    owner: "sara",
    live: false
},{
    post_text: "welcome",
    images: ["image1.jpg", "image2.jpg"],
    likes: 10,
    comments: ["good", "done"],
    Datetime: new Date(),
    owner: "wael",
    live: false
},{
    post_text: "Hello!",
    images: ["image1.jpg", "image2.jpg"],
    likes: 5,
    comments: ["nice", "good morning"],
    Datetime: new Date(),
    owner: "amira",
    live: false
},{
    post_text: "Hello!",
    images: ["image1.jpg", "image2.jpg"],
    likes: 10,
    comments: ["nice", "good"],
    Datetime: new Date(),
    owner: "sayed02",
    live: true
},{
    post_text: "Hello!",
    images: ["image1.jpg", "image2.jpg"],
    likes: 10,
    comments: ["goodbye", "nice"],
    Datetime: new Date(),
    owner: "habiba",
    live: true
},{
    post_text: "Hello!",
    images: ["image1.jpg", "image2.jpg"],
    likes: 2,
    comments: ["wallet", "dress"],
    Datetime: new Date(),
    owner: "ali",
    live: true
},{
    post_text: "Hello!",
    images: ["image1.jpg", "image2.jpg"],
    likes: 7,
    comments: ["true", "false"],
    Datetime: new Date(),
    owner: "mona",
    live: true
}])
//8.Insert 10 users.
>db.users.insertMany([
    { username: "osama", email: "osma@gmail.com" },
    { username: "ali", email: "ali@gmail.com" },
    { username: "khalid", email: "khalid@gmail.com" },
    { username: "mohamed", email: "mohamed@gmail.com" },
    { username: "wael", email: "wael@gmail.com" },
    { username: "fouad", email: "fouad@gmail.com" },
    { username: "nada", email: "nada@gmail.com" },
    { username: "amira", email: "amira@gmail.com" },
    { username: "sara", email: "sara@gmail.com" },
    { username: "hussein", email: "hussein@gmail.com" }
]);
//9.Display all users.
>db.users.find();
//10.Display user “mohamed” posts
>db.posts.find({ owner: "mohamed" }).pretty();
//11.Update mohamed's posts set likes 10000
>db.posts.updateMany({ owner: "mohamed" }, { $set: { likes: 10000 } });
//12.delete Mohamed ‘s posts
>db.posts.deleteMany({ owner: "mohamed" });


