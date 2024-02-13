module.exports.Car = class Car
{
    constructor(_model,_year)
    {
        this.model =_model;
        this.year = _year;
    }

    toString()
    {
        return `Car -> model=${this.model}, year=${this.year},`;
    }
}
