import React, { useState } from 'react';
import { Label, List } from 'reactstrap';


// Сделай запрос к сервверу чтобы получить все пункты
const MenuItem = ({ item }) => {
  const hasSubMenu = item.submenu && item.submenu.length > 0;
  return (
    <li>
      <a href={item.link}>{item.label}</a>
      {hasSubMenu && <Menu items={item.submenu} />}
    </li>
  );
};

const Menu = ({ items }) => {
  return (
    <ul>
      {items.map((item) => (
        <MenuItem key={item.id} item={item} />
      ))}
    </ul>
  );
};

export default Menu;
