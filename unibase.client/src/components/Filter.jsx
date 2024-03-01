import React, { useState } from 'react';
import './Filter.css';

function Filter({ list }) {
    const [valuesF, setValues] = useState(true);
    const [filteredValue, setFilteredValue] = useState('');
    var id = 0;
    var values = list
    function updateInput(value) {
        console.log(value);
        setFilteredValue(value);
    }
    return (
        <div >
            <div className='filter_container'> <input
                onFocus={() => setValues(false)}
                onBlur={() => setValues(true)}
                className='filter_input'
                readOnly={true}
                value={filteredValue}
               
            ></input>
            </div>
           
            {!valuesF && (
                <div className='column_box'>
                    {values.map((l) => (
                        <div onMouseDown={() => updateInput(l)} key={id++} className='border_box'>
                            <div>
                                <p className='text'>{l}</p>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
}

export default Filter;
