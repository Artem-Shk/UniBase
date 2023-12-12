import React, { Component } from 'react';
import  JournalAnalitic  from './JournalAnalitic.jsx';
export class Home extends Component {
  static displayName = Home.name;
 
    render() {
    return (
      <div style={{height: '100%'}}>
        <h1>Приложение по аналитики журналов</h1>
        <p>Это встречающая страница</p>
         <JournalAnalitic />
      </div>
    );
  }
}
