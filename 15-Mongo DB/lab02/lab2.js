//display the number of products per category
db.products.aggregate([
  { $group: { _id: "$category", count: { $sum: 1 } } }
])
//display the max category products price
db.products.aggregate([
  { $group: { _id: "$category", maxPrice: { $max: "$price" } } }
])
//display user ahmed orders populated with product:
db.orders.aggregate([
  { $match: { user: "Ahmed" } },
  { $unwind: "$products" },
  { $lookup: { from: "products", localField: "products.productId", foreignField: "_id", as: "populatedProducts" } }
])
//get user ahmed highest order price:
db.orders.aggregate([
  { $match: { user: "Ahmed" } },
  { $unwind: "$products" },
  { $lookup: { from: "products", localField: "products.productId", foreignField: "_id", as: "populatedProducts" } },
  { $unwind: "$populatedProducts" },
  { $group: { _id: "$user", maxOrderPrice: { $max: "$populatedProducts.price" } } }
])
//select products with a price greater than 1000 and less than 5000
db.Inventory.find({ price: { $gt: 1000, $lt: 5000 } }, { name: 1, price: 1 })
//display products which have a phone number for the vendor (two ways):
//1.
db.Inventory.find({ "vendor.phone": { $exists: true } })
//2.
db.Inventory.find({ "vendor.phone": { $ne: null } })
//display products which are available in 4 stocks at the same time:
db.Inventory.find({ stock: { $size: 4 } })
//increase all products by 500 EGP
db.Inventory.updateMany({}, { $inc: { price: 500 } })
//replace stock #30 with #60 in all products:
db.Inventory.updateMany({ stock: 30 }, { $set: { "stock.$": 60 } })
//remove stock 70 from all products:
db.Inventory.updateMany({}, { $pull: { stock: 70 } })
//display only product name and vendor phone number:
db.Inventory.find({}, { name: 1, "vendor.phone": 1, _id: 0 })
//display the most expensive product:
db.Inventory.find().sort({ price: -1 }).limit(1)

