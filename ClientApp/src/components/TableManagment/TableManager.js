import React, { useState, useEffect } from 'react';
import { Col, Row, Table } from 'reactstrap';
import { useSelector } from 'react-redux/es/hooks/useSelector';
import SearchBar from './SearchBar';
import Menu from './LeftMenu';
import store from '../../store';
import { fetchFaculiesNames } from '../../actions';
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
