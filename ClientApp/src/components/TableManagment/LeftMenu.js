import React, { useState } from 'react';

const Menu = () => {
  const [menu, setMenu] = useState(false);
  const [submenu1, setSubmenu1] = useState(false);
  const [submenu2, setSubmenu2] = useState(false);

  const handleMenu = () => {
    setMenu(!menu);
    setSubmenu1(false);
    setSubmenu2(false);
  };

  const handleSubmenu1 = () => {
    setSubmenu1(!submenu1);
    setSubmenu2(false);
  };

  const handleSubmenu2 = () => {
    setSubmenu2(!submenu2);
  };

  return (
    <nav>
      <ul>
        <li>
          <a onClick={handleMenu}>
            ЭФ
          </a>
          {menu && (
            <ul>
              <li>
                <a onClick={handleSubmenu1}>
                  Подпункт 1.1
                </a>
                {submenu1 && (
                  <ul>
                    <li>
                      <a >Подпункт 1.1.1</a>
                    </li>
                    <li>
                      <a>Подпункт 1.1.2</a>
                    </li>
                  </ul>
                )}
              </li>
              <li>
                <a  onClick={handleSubmenu2}>
             
                </a>
                {submenu2 && (
                  <ul>
                    <li>
                      <a >Подпункт 1.2.1</a>
                    </li>
                    <li>
                      <a >Подпункт 1.2.2</a>
                    </li>
                  </ul>
                )}
              </li>
              <li>
                <a >Подпункт 1.3</a>
              </li>
            </ul>
          )}
        </li>
        <li>
          <a >Пункт 2</a>
        </li>
        <li>
          <a >Пункт 3</a>
        </li>
      </ul>
    </nav>
  );
};

export default Menu;