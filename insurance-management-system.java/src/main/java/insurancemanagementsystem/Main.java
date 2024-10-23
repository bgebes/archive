package insurancemanagementsystem;

import insurancemanagementsystem.cli.InputHelper;
import insurancemanagementsystem.models.Account.Account;
import insurancemanagementsystem.models.Account.Manager.AccountManager;

public class Main {
    public static void main(String[] args) {
        AccountManager manager = new AccountManager();

        while (true) {
            String email, password;
            int process;

            System.out.println("Options\n1-Create Account\n2-Login\n3-Exit\n4-Admin Login");
            System.out.print("Enter the process: ");
            process = Integer.parseInt(InputHelper.scanner.nextLine().trim());

            switch (process) {
                case 1 -> manager.createAccount();
                case 2 -> {
                    System.out.print("Enter your email address: ");
                    email = InputHelper.scanner.nextLine().trim();
                    System.out.print("Enter your password: ");
                    password = InputHelper.scanner.nextLine().trim();
                    manager.login(email, password);
                }
                case 3 -> System.exit(0);
                case 4 -> {
                    System.out.print("Please enter the admin password: ");
                    String password2 = InputHelper.scanner.nextLine().trim();
                    if (password2.equals("admin1234")) {
                        System.out.println("Printing all accounts and passwords in the system ...");
                        for (Account a : manager.getAccounts())
                            System.out.println(a);

                    }
                }
            }

        }
    }
}