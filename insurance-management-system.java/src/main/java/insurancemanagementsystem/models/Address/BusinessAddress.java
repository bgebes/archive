package insurancemanagementsystem.models.Address;

import java.util.Map;

public class BusinessAddress extends Address {
    public BusinessAddress(String street, int buildingNumber, int doorNumber, String district, String city, String country) {
        super(street, buildingNumber, doorNumber, district, city, country);
    }

    public BusinessAddress(Map<String, String> map) {
        super(map);
    }

    @Override
    public String getAddress() {
        return String.format("Business Address: %s No: %d/%d %s %s/%s", getStreet(), getBuildingNumber(), getDoorNumber(), getDistrict(), getCity(), getCountry());
    }
}
