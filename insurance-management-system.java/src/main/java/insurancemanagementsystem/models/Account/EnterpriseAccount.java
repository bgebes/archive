package insurancemanagementsystem.models.Account;

import insurancemanagementsystem.models.Insurance.Insurance;
import insurancemanagementsystem.models.User.User;
import insurancemanagementsystem.utilities.Enums;

import java.util.List;

public class EnterpriseAccount extends Account {
    public static final double profitMargin = 1.25;

    public EnterpriseAccount(User user, List<Insurance> insuranceList, Enums.AuthenticationStatus isLogin) {
        super(user, insuranceList, isLogin);
    }

    @Override
    public void addInsurancePolicy(Insurance insurance) {
        insurance.setPrice(insurance.calculate() * profitMargin);
        super.getInsuranceList().add(insurance);
    }
}
