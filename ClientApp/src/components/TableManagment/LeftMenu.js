import React, { useState } from 'react';
import { Label, List } from 'reactstrap';


// Сделай запрос к сервверу чтобы получить все пункты
const MenuItem = ({ item }) => {
    const hasSubMenu = item.GroupName && item.GroupName.length > 0;
  return (
      <li>
          <a >{item.FaculityName}</a>
      {hasSubMenu && <Menu items={item.GroupName} />}
    </li>
  ); 
};

const Menu = ({ items }) => {
  return (
    <ul>
      {items.map((item) => (
        <MenuItem key={item.FaculityName} item={item} />
      ))}
    </ul>
  );
};

export default Menu;
