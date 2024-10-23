package insurancemanagementsystem.models.Address;

import lombok.Getter;
import lombok.Setter;

import java.util.Map;

@Getter
@Setter
public abstract class Address {
    private String street;
    private int buildingNumber;
    private int doorNumber;
    private String district;
    private String city;
    private String country;

    public Address(String street, int buildingNumber, int doorNumber, String district, String city, String country) {
        this.street = street;
        this.buildingNumber = buildingNumber;
        this.doorNumber = doorNumber;
        this.district = district;
        this.city = city;
        this.country = country;
    }

    public Address(Map<String, String> map) {
        this.street = map.get("street");
        this.buildingNumber = Integer.parseInt(map.get("buildingNumber"));
        this.doorNumber = Integer.parseInt(map.get("doorNumber"));
        this.district = map.get("district");
        this.city = map.get("city");
        this.country = map.get("country");
    }

    public abstract String getAddress();

    public static String[] getInputKeys() {
        return new String[]{"street", "buildingNumber", "doorNumber", "district", "city", "country"};
    }

    @Override
    public String toString() {
        return getAddress();
    }
}
