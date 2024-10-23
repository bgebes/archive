package insurancemanagementsystem.models.Insurance;

import insurancemanagementsystem.utilities.CustomStructures;

public class ResidenceInsurance extends Insurance {
    private static final double insuranceMargin = 15;

    public ResidenceInsurance(String name, double price, CustomStructures.DateRange dateRange) {
        super(name, price, dateRange);
    }

    @Override
    public double calculate() {
        return super.getDateRange().differenceInBetween() * insuranceMargin;
    }
}
