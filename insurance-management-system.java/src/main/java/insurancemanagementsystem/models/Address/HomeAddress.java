package insurancemanagementsystem.models.Address;

import java.util.Map;

public class HomeAddress extends Address {
    public HomeAddress(String street, int buildingNumber, int doorNumber, String district, String city, String country) {
        super(street, buildingNumber, doorNumber, district, city, country);
    }

    public HomeAddress(Map<String, String> map) {
        super(map);
    }

    @Override
    public String getAddress() {
        return String.format("Home Address: %s No: %d/%d %s %s/%s", getStreet(), getBuildingNumber(), getDoorNumber(), getDistrict(), getCity(), getCountry());
    }
}
