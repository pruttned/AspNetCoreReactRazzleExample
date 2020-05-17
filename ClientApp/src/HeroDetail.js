import React from 'react';
import { Link } from 'react-router-dom';
import page from './page';

const HeroDetail = ({ pageData }) => (
  <div>
    <h2>{pageData.name}</h2>
    <div>
      Height: {pageData.height}
    </div>
    <div>
      Mass: {pageData.mass}
    </div>
    <div>
      BirthYear: {pageData.birthYear}
    </div>
    <div>
      <Link to="/">Back to list</Link>
    </div>
  </div>
);

export default page(HeroDetail);