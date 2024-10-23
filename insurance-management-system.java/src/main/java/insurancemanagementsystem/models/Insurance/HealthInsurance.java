package insurancemanagementsystem.models.Insurance;

import insurancemanagementsystem.utilities.CustomStructures;

public class HealthInsurance extends Insurance {
    private static final double insuranceMargin = 12;

    public HealthInsurance(String name, double price, CustomStructures.DateRange dateRange) {
        super(name, price, dateRange);
    }

    @Override
    public double calculate() {
        return super.getDateRange().differenceInBetween() * insuranceMargin;
    }
}
