package insurancemanagementsystem.models.Insurance;

import insurancemanagementsystem.utilities.CustomStructures;

public class TravelInsurance extends Insurance {
    private static final double insuranceMargin = 20;

    public TravelInsurance(String name, double price, CustomStructures.DateRange dateRange) {
        super(name, price, dateRange);
    }

    @Override
    public double calculate() {
        return super.getDateRange().differenceInBetween() * insuranceMargin;
    }
}
