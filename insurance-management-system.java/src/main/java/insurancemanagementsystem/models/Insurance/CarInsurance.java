package insurancemanagementsystem.models.Insurance;

import insurancemanagementsystem.utilities.CustomStructures;

public class CarInsurance extends Insurance {
    private static final double insuranceMargin = 10;

    public CarInsurance(String name, double price, CustomStructures.DateRange dateRange) {
        super(name, price, dateRange);
    }

    @Override
    public double calculate() {
        return super.getDateRange().differenceInBetween() * insuranceMargin;
    }
}
