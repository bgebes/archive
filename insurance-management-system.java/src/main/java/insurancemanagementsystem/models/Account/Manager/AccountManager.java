package insurancemanagementsystem.models.Account.Manager;

import insurancemanagementsystem.cli.InputHelper;
import insurancemanagementsystem.exceptions.InvalidAuthenticationException;
import insurancemanagementsystem.models.Account.Account;
import insurancemanagementsystem.models.Account.EnterpriseAccount;
import insurancemanagementsystem.models.Account.IndividualAccount;
import insurancemanagementsystem.models.User.User;
import insurancemanagementsystem.utilities.Enums;
import lombok.Getter;

import java.util.*;
import java.util.stream.Collectors;

@Getter
public class AccountManager {
    private final TreeSet<Account> accounts;

    public AccountManager() {
        accounts = new TreeSet<>();
    }

    public Account login(String email, String password) {
        Account account = accounts.stream().filter(a -> {
            User user = a.getUser();
            return Objects.equals(user.getEmail(), email) && Objects.equals(user.getPassword(), password);
        }).findFirst().orElse(null);

        try {
            if (account != null) {
                account.login();
            } else {
                throw new InvalidAuthenticationException();
            }
        } catch (InvalidAuthenticationException e) {
            throw new RuntimeException(e.getMessage());
        }

        return account;
    }

    public void createAccount() {
        String[] inputKeys = User.getInputKeys();
        List<String> list = Arrays.stream(inputKeys).collect(Collectors.toList());
        list.add("Account Type");

        Map<String, String> inputs = InputHelper.getInputViaKeys(list.toArray(new String[0]));
        String accountType = inputs.get("Account Type");

        Account account;
        if (Objects.equals(accountType, "Individual")) {
            account = new IndividualAccount(
                    new User(inputs),
                    new ArrayList<>(),
                    Enums.AuthenticationStatus.FAIL
            );
        } else if (Objects.equals(accountType, "Enterprise")) {
            account = new EnterpriseAccount(
                    new User(inputs),
                    new ArrayList<>(),
                    Enums.AuthenticationStatus.FAIL
            );
        } else {
            throw new NullPointerException();
        }

        accounts.add(account);
        System.out.printf("%s created!\n", account);
    }
}
