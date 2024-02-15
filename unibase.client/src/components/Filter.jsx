import React, { useState } from 'react';
import './Filter.css'
function Filter({ list }) {
    const [values, setVisibleValue] = useState([]);

    function setValues(newValues) {
        setVisibleValue(newValues);
    }
    return (
        <div>
            <input
                onFocus={() => setValues(['AAAAAAAAAAAAA', 'XXXXXXXXXXXXXXXasd','GHGFASDGHAS'])}
                onBlur={() => setValues([])}
            />
            {values.length > 0 && (
                values.map((l, index) => (
                    <div className='column_box' >
                        <div key={index} className='border_box' style={{top: `${index * 70}px` }}>
                            <div><p className='text'>{l}</p><div/>
                            </div>
                        </div>
                    </div>
                ))
            )}
        </div>
    );
}

export default Filter;