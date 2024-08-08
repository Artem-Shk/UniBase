import React, { useState } from 'react';



// Сделай запрос к сервверу чтобы получить все пункты
const MenuItem = ( {MenuitemObj} ) => {
    const hasSubMenu = MenuitemObj.GroupName && MenuitemObj.GroupName.length > 0;
    console.log(MenuitemObj)
  return (
      <li> 
          <a >{MenuitemObj.ItemName}</a>
      {hasSubMenu && <Menu items={MenuitemObj.GroupName} />}
    </li>
  ); 
};

const Menu = ( {items} ) => {

  return ( 
    <ul>
      { 
      items.map((item) => (
        <MenuItem key={item.ItemName} MenuitemObj={item} />
      ))}
    </ul>
  );
};

export default Menu;
