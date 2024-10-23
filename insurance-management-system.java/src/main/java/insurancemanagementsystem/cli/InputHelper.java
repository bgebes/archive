package insurancemanagementsystem.cli;

import org.apache.commons.lang3.StringUtils;

import java.util.*;

public class InputHelper {
    public static Scanner scanner = new Scanner(System.in);

    public static Map<String, String> getInputViaKeys(String... keys) {
        Map<String, String> inputs = new HashMap<>();

        for (String key : keys) {
            System.out.printf("%s: ", StringUtils.capitalize(key));
            String input = scanner.nextLine().trim();
            inputs.put(key, input);
        }

        return inputs;
    }
}
