import React, { useState } from 'react';
import './Filter.css';

function Filter({ FilterRef, list }) {
    const [valuesF, setValues] = useState(true);
    const [filteredValue, setFilteredValue] = useState(list[0]);
    var id = 0;
    var values = list
    function updateInput(value) {
        setFilteredValue(value);
    }
    return (
        <div className='filter_container_container' >
            <div className='filter_container'>
                <input
              
                onFocus={() => setValues(false)}
                onBlur={() => setValues(true)}
                className='filter_input'
                readOnly={true}
                    value={filteredValue}
                    ref={FilterRef}
                
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
