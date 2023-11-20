import React, { Component } from 'react';
import { useSelector } from 'react-redux/es/hooks/useSelector';
import store from '../store';
import  JournalAnalitic  from './JournalAnalitic.js';
export class Home extends Component {
  static displayName = Home.name;
 
    render() {
    return (
      <div style={{width:'100%',}}>
        <h1>Приложение по аналитики журналов</h1>
        <p>Это встречающая страница</p>
         <JournalAnalitic />
      </div>
    );
  }
}
