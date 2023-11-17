import React from 'react';
import { Link } from 'react-router-dom';
import '../Styles/HeaderStyle.css';

const Header: React.FC = () => {
  return (
    <header className="header">
      <nav className="headerNav">
        <ul className="headerul">
          <Link to="/">
            <li className="headerli">Home</li>
          </Link>
          <Link to="/Utilisateur">
          <li className="headerli">Profil</li>
          </Link>
          <Link to="/">
          <li className="headerli">Déconnexion</li>
          </Link>
        </ul>
      </nav>
    </header>
  );
};

export default Header;