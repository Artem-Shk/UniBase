import React, { useState, useEffect } from 'react';
import { Col, Row, Table } from 'reactstrap';
import { useSelector } from 'react-redux/es/hooks/useSelector';
import SearchBar from './SearchBar';
import store from '../../store';


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

function StudentTable() {
  const persons = useSelector(state => state.table.data || []);
  const fields = Object.keys(persons[0] || {});
  return (
    <Table dark>
      <thead>
        <tr>
          {fields.map((element) => (
            <th key={element}>{element}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {persons.map((person, index) => (
          <tr key={index}>
            {fields.map((field) => (
              <td key={field}>{person[field]}</td>
            ))}
          </tr>
        ))}
      </tbody>
    </Table>
  );
}

  // useEffect(() => {
  //   const unsubscribe = store.subscribe(() => {
  //     const res = store.getState().table.data;
  //     if (res === null) {
  //       console.log('Ошибка: данные не получены');
  //     } else {
  //       const persons = res.data;
  //       setPersons(persons);
  //       const fields = Object.keys(persons[0]);
  //       setFields(fields);
  //     }
  //   });

  //   return () => {
  //     unsubscribe();
  //   };
  // }, []);

 

//TODO: make elements static
export function TableManager() {
  return (
    <div>
      <Row className="align-items-left justify-content-start">
        <Col sm={2}>
          <SearchBar />
          <VerticalMenu />
        </Col>
        <Col sm={2}>
          <StudentTable />
        </Col>
      </Row>
    </div>
  );
}
