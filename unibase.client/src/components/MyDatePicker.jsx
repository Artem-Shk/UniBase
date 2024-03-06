import React, { forwardRef, useState } from 'react';
import DatePicker from "react-datepicker";
import './MyDatePicker.css'

function MyDatePicker({ defaultDate }) {
    const [dateRange, setDateRange] = useState([null, null]);
    const [startDate, endDate] = defaultDate;
    const CustomInput = forwardRef(({ value, onClick }, ref) =>
    (
        <button className='custom-input' onClick={onClick} ref={ref}>
            {value}
        </button>
    ));
    return (
        <DatePicker

            selectsRange={true}
            startDate={startDate}
            endDate={endDate}
            onChange={(update) => {
                setDateRange(update);
            }}
            isClearable={true}
            customInput={<CustomInput />}
            showIcon
        />
    )
}
export default MyDatePicker;