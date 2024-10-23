package insurancemanagementsystem.models.Account;

import insurancemanagementsystem.exceptions.InvalidAuthenticationException;
import insurancemanagementsystem.models.Address.Manager.AddressManager;
import insurancemanagementsystem.models.Insurance.Insurance;
import insurancemanagementsystem.models.User.User;
import insurancemanagementsystem.utilities.Enums;
import lombok.Getter;
import lombok.Setter;

import java.sql.Date;
import java.time.Instant;
import java.util.List;

@Getter
@Setter
public abstract class Account implements Comparable<Account> {
    private User user;
    private List<Insurance> insuranceList;
    private Enums.AuthenticationStatus isLogin;

    public Account(User user, List<Insurance> insuranceList, Enums.AuthenticationStatus isLogin) {
        this.user = user;
        this.insuranceList = insuranceList;
        this.isLogin = isLogin;
    }

    public abstract void addInsurancePolicy(Insurance insurance);

    public final void showUserInfo() {
        String userInfo = "---------- USER INFO ----------\n" +
                String.format("Name: %s\n", user.getName()) +
                String.format("Surname: %s\n", user.getSurname()) +
                String.format("Email: %s\n", user.getEmail()) +
                String.format("Job: %s\n", user.getJob()) +
                String.format("Age: %d\n", user.getAge()) +
                String.format("Address List: %s\n", user.getAddressList()) +
                String.format("Last Login Date: %s\n", user.getLastLogin()) +
                "-------------------------------\n";

        System.out.print(userInfo);
    }

    public void addAddress() {
        AddressManager.insertAddress(this);
    }

    public void deleteAddress() {
        AddressManager.deleteAddress(this);
    }

    public Enums.AuthenticationStatus loginStatus() {
        return this.isLogin;
    }

    public void login() throws InvalidAuthenticationException {
        this.isLogin = Enums.AuthenticationStatus.SUCCESS;
        this.user.setLastLogin(Date.from(Instant.now()));
        System.out.println("Logged In!");
    }

    @Override
    public int compareTo(Account other) {
        return this.user.getName().compareTo(other.getUser().getName());
    }

    @Override
    public String toString() {
        return "---------- USER INFO ----------\n" +
                String.format("Name: %s\n", user.getName()) +
                String.format("Surname: %s\n", user.getSurname()) +
                String.format("Email: %s\n", user.getEmail()) +
                String.format("Job: %s\n", user.getJob()) +
                String.format("Age: %d\n", user.getAge()) +
                String.format("Address List: %s\n", user.getAddressList()) +
                String.format("Last Login Date: %s\n", user.getLastLogin()) +
                "-------------------------------\n";
    }
}
