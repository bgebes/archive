package insurancemanagementsystem.utilities;

import lombok.Getter;
import lombok.Setter;

import java.time.temporal.TemporalField;
import java.util.Date;

public class CustomStructures {
    @Getter
    @Setter
    public static class DateRange {
        private Date start;
        private Date end;

        public DateRange(Date start, Date end) {
            this.start = start;
            this.end = end;
        }

        public int differenceInBetween() {
            return (int) ((end.getTime() - start.getTime()) / 60000);
        }
    }
}
