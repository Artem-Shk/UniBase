import React, { Component } from 'react';
import { useSelector } from 'react-redux/es/hooks/useSelector';
import store from '../store';
import  JournalAnalitic  from './JournalAnalitic.js';
export class Home extends Component {
  static displayName = Home.name;
 
    render() {
    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Welcome to your new single-page application, built with:</p>
         <JournalAnalitic />
      </div>
    );
  }
}
