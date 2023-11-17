import React from 'react';
import { Link } from 'react-router-dom';
import '../Styles/WelcomePageStyle.css'

const WelcomePage: React.FC = () => {
  return (

      <div className="container">
        <div className="btn-container">

          <Link to="/Utilisateur">
            <button className="start-btn">Connexion</button>
          </Link>

        </div>
      </div>
  );
};

export default WelcomePage;

