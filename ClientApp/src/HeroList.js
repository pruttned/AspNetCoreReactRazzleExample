import React from 'react';
import { Link } from 'react-router-dom';
import page from './page';

const HeroList = ({ pageData }) => (
  <div>
    <h2>List of heroes</h2>
    <div>
      <ul>
        {pageData.map(hero => (
          <li key={hero.id}>
            <Link to={`/${hero.id}`}>{hero.name}</Link>
          </li>
        ))}
      </ul>
    </div>
  </div>
);

export default page(HeroList);
