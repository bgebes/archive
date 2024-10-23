package insurancemanagementsystem.models.Address.Manager;

import insurancemanagementsystem.cli.InputHelper;
import insurancemanagementsystem.models.Account.Account;
import insurancemanagementsystem.models.Address.Address;
import insurancemanagementsystem.models.Address.BusinessAddress;
import insurancemanagementsystem.models.Address.HomeAddress;

import java.util.*;
import java.util.stream.Collectors;

public class AddressManager {
    public static void insertAddress(Account account) {
        String[] inputKeys = Address.getInputKeys();
        List<String> list = Arrays.stream(inputKeys).collect(Collectors.toList());
        list.add("Address Type");

        Map<String, String> inputs = InputHelper.getInputViaKeys(list.toArray(new String[0]));
        String accountType = inputs.get("Address Type");

        Address address;
        if (Objects.equals(accountType, "Home")) {
            address = new HomeAddress(inputs);
        } else if (Objects.equals(accountType, "Business")) {
            address = new BusinessAddress(inputs);
        } else {
            throw new NullPointerException();
        }

        account.getUser().getAddressList().add(address);
        System.out.printf("%s created!\n", address);
    }

    public static void deleteAddress(Account account) {
        List<Address> addressList = account.getUser().getAddressList();
        if (addressList.isEmpty()) throw new NullPointerException();

        StringBuilder listingBuilder = new StringBuilder();

        listingBuilder.append("---------- Address List ----------\n");
        for (int i = 0; i < addressList.size(); i++) {
            Address address = addressList.get(i);

            listingBuilder.append(String.format("%d- %s\n", i, address));
        }
        System.out.print(listingBuilder);

        System.out.print("Which do you want to delete?: ");
        int index = Integer.parseInt(InputHelper.scanner.nextLine().trim());

        Address deleted = addressList.remove(index);
        System.out.printf("%s deleted!\n", deleted);
    }
}
