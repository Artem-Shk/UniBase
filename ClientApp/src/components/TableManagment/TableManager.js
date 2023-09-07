import React, { useState, useEffect } from 'react';
import { Col, Row, Table } from 'reactstrap';
import { useSelector } from 'react-redux/es/hooks/useSelector';
import SearchBar from './SearchBar';
import Menu from './LeftMenu';
import store from '../../store';
import { fetchFaculiesNames } from '../../actions';


const fagots = [
  {
    id: 1,
    label: 'ss',
    link: '#',
    submenu: [
      { id: 11, label: 'Subitem 1', link: '#' },
      { id: 12, label: 'Subitem 2', link: '#' },
      { id: 13, label: 'Subitem 3', link: '#' },
    ],
  },
  {
    id: 2,
    label: 'dasd',
    link: '#',
    submenu: [
      { id: 21, label: 'Subitem 1', link: '#' },
      { id: 22, label: 'Subitem 2', link: '#' },
    ],
  },
  {
    id: 3,
    label: 'asdasdasd',
    link: '#',
    submenu: [
      { id: 31, label: 'Subitem 1', link: '#' },
      { id: 32, label: 'Subitem 2', link: '#' },
      { id: 33, label: 'Subitem 3', link: '#' },
      { id: 34, label: 'Subitem 4', link: '#' },
    ],
  },
];
function StudentTable() {
   // redux hook for watch to store changes
   const persons = useSelector(state =>  state.table.data || state.table.status);
   
   if(persons !== 200){
     return (<a>Нечего не найдено</a>);
   }
   else{
    const fields = Object.keys(persons[0] || {})
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
}
 
export function TableManager() {
  const menuitem = useSelector(state =>  state.menu.data || null);

  return (
    <div>
      <Row className="align-items-left justify-content-start">
        <Col sm={2}>
          <SearchBar />
          <Menu items = {menuitem}/>
        </Col>
        <Col sm={2}>
          <StudentTable />
        </Col>
      </Row>
    </div>
  );
}
