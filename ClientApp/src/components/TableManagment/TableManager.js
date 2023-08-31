import React, { useState, useEffect } from 'react';
import { Col, Row, Table } from 'reactstrap';
import { useSelector } from 'react-redux/es/hooks/useSelector';
import SearchBar from './SearchBar';
import Menu from './LeftMenu';
//burgermenu
function VerticalMenu() {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const handleMenuClick = () => {
    setIsMenuOpen(prevState => !prevState);
  };

  const handleClick = (event) => {
    console.log(event.target.innerText);
  }

  const SubMenu = ({ items }) => {
    return (
      <ul>
        {items.map(item => (
          <li key={item.id} onClick={handleClick}>{item.title}
            {item.subItems && <SubMenu items={item.subItems} />}
          </li>
        ))}
      </ul>
    );
  };

  const menuItems = [
    {
      id: 1,
      title: 'ЭФ',
      subItems: [
        { id: 11, title: 'Подразделение 1' },
        { id: 12, title: 'Подразделение 2' },
      ],
    },
    {
      id: 2,
      title: 'ЮФ',
      subItems: [
        { id: 21, title: 'Подразделение 1' },
        { id: 22, title: 'Подразделение 2' },
      ],
    },
    {
      id: 3,
      title: 'ИФФ',
      subItems: [
        { id: 31, title: 'Подразделение 1' },
        { id: 32, title: 'Подразделение 2' },
      ],
    },
    { id: 4, title: 'ДБВиЭН' },
    { id: 5, title: 'ОСПО' },
    { id: 6, title: 'ДИЯ' },
  ];

  return (
    <div>
      <button onClick={handleMenuClick}>Меню</button>
      {isMenuOpen && <SubMenu items={menuItems} />}
    </div>
  );
}

function StudentTable() {

  // redux hook for watch to store changes
  const persons = useSelector(state => state.table.data || state);
  console.log(persons)
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
//TODO: make elements static
export function TableManager() {

  return (
    <div>
      <Row className="align-items-left justify-content-start">
        <Col sm={2}>
          <SearchBar />
          <Menu />
        </Col>
        <Col sm={2}>
          <StudentTable />
        </Col>
      </Row>
    </div>
  );
}
