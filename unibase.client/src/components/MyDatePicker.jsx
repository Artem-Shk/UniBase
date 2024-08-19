import React, { forwardRef, useState } from 'react';
import DatePicker from "react-datepicker";
import './MyDatePicker.css'

function MyDatePicker({ DatePickerRef, defaultDate }) {
    const [dateRange, setDateRange] = useState(defaultDate);
    const [startDate, endDate] = dateRange;
    const CustomInput = forwardRef(({ value, onClick }, ref) =>
    (
        
        <button className='custom-input' onClick={onClick} ref={ref}>
            {value}
        </button>
    ));

    return (
        <DatePicker
            ref={DatePickerRef}
            selectsRange={true}
            startDate={startDate}
            endDate={endDate}
            onChange={(update,e) => {
                setDateRange(update);
               
            }}
            className='z-index:6'
            isClearable={true}
            customInput={<CustomInput />}
            showIcon
            dateFormat = "dd.MM.yyyy"
        />
    )
}
export default MyDatePicker;