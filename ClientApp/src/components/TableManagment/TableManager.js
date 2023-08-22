import React, { useState, useEffect } from 'react';
import { Table } from 'reactstrap';
import axios from 'axios';
// TODO: Add named Fields
function SearchBar() {
  return (
    <div style={{ height: 46, left: 0 }}>
      <input type='text' />
    </div>
  )
}

function VerticalMenu() {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const handleMenuClick = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  return (
    <div>
      <button onClick={handleMenuClick}>Меню</button>
      {isMenuOpen && (
        <ul>
          <li key="1">Пункт 1</li>
          <li key="2">Пункт 2</li>
          <li key="3">Пункт 3</li>
        </ul>
      )}
    </div>
  );
}

function StudentTable({ name = 'Name' }) {
  const [persons, setPersons] = useState([]);
  const [fields, setFields] = useState([]);
  useEffect(() => {
    axios.get('studentdata/GetJsonTableRowData/Иван')
      .then(res => {
        const persons = res.data;
        setPersons(persons);
		const fields = Object.keys(persons[0]);
		setFields(fields);
		
      })
  }, []);

  return (
    <Table dark>
      <thead>
	  <tr >
	   {fields.map((element) => (
    			<th>{element}</th>
		))}
	  </tr>    
      </thead>
      <tbody>
        {persons.map((person, index) => (
		  <tr key = {index}>
			{fields.map((field)=>(
					<td>{person[field]}</td>)
				)
			}
		  </tr>))}
      </tbody>
    </Table>
  );
}

export function TableManager() {
  return (
    <div>
      <SearchBar />
      <div>
        <VerticalMenu />
        <StudentTable />
      </div>
    </div>
  );
}
  