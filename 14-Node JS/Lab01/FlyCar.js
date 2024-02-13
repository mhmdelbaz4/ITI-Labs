let {Car} = require("./car.js");

module.exports.FlyingCar = class FlyingCar extends Car{
    
    constructor(_model,_year,_canFly)
    {
        super(_model,_year);
        this.canFly = _canFly;
    }

    toString()
    {
        let result =super.toString();
        result += this.canFly ? "I Can Fly" : "I Can't Fly";
        return result;
    }
}