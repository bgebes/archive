package insurancemanagementsystem.models.User;

import insurancemanagementsystem.models.Address.Address;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

@Getter
@Setter
public class User {
    private String name;
    private String surname;
    private String email;
    private String password;
    private String job;
    private int age;
    private List<Address> addressList;
    private Date lastLogin;

    public User(String name, String surname, String email, String password, String job, int age, List<Address> addressList, Date lastLogin) {
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.password = password;
        this.job = job;
        this.age = age;
        this.addressList = addressList;
        this.lastLogin = lastLogin;
    }

    public User(Map<String, String> map) {
        this.name = map.get("name");
        this.surname = map.get("surname");
        this.email = map.get("email");
        this.password = map.get("password");
        this.job = map.get("job");
        this.age = Integer.parseInt(map.get("age"));
        this.addressList = new ArrayList<>();
        this.lastLogin = Date.from(Instant.now());
    }

    public static String[] getInputKeys() {
        return new String[]{"name", "surname", "email", "password", "job", "age"};
    }
}
