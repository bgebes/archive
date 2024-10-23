package insurancemanagementsystem.models.Insurance;

import insurancemanagementsystem.utilities.CustomStructures;
import lombok.Getter;
import lombok.Setter;

import java.util.Date;

@Getter
@Setter
public abstract class Insurance {
    private String name;
    private double price;
    private CustomStructures.DateRange dateRange;

    public Insurance(String name, double price, CustomStructures.DateRange dateRange) {
        this.name = name;
        this.price = price;
        this.dateRange = dateRange;
    }

    public abstract double calculate();
}
