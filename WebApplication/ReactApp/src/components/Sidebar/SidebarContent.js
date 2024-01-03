import React, { useState, useContext, Suspense, useEffect, lazy } from 'react'
import routes from '../../routes/sidebar'
import { NavLink, Route } from 'react-router-dom'
import * as Icons from '../../icons'
import SidebarSubmenu from './SidebarSubmenu'
import { Button } from '@windmill/react-ui'
import { obtenerClaims } from '../../utils/auth/manejadorJWT';
import AuthContext from '../../context/AuthContext'

function Icon({ icon, ...props }) {
  const Icon = Icons[icon]
  return <Icon {...props} />
}

function SidebarContent() {

  const [claims, setClaims] = useState([]);

  useEffect(() => {
    setClaims(obtenerClaims());    
  }, [])

  function actualizar(claims) {
    setClaims(claims);
  } 

  function existResourse(resourse) {
        
    return claims.findIndex(claim => claim.valor === resourse) > -1;
  }

  return (
    <div className="py-4 text-gray-500 dark:text-gray-400">
      <AuthContext.Provider value={{ claims, actualizar }}>
      <ul className="mt-6">
        {routes.map((route) =>
          existResourse(route.resourse)?
          route.routes ? (
            <SidebarSubmenu route={route} claim ={claims} key={route.name} />
          ) : (
            <li className="relative px-6 py-3" key={route.name}>
              <NavLink
                exact
                to={route.path}
                className="inline-flex items-center w-full text-sm font-semibold transition-colors duration-150 hover:text-gray-800 dark:hover:text-gray-200"
                activeClassName="text-gray-800 dark:text-gray-100"
              >
                <Route path={route.path} exact={route.exact}>
                  <span
                    className="absolute inset-y-0 left-0 w-1 bg-purple-600 rounded-tr-lg rounded-br-lg"
                    aria-hidden="true"
                  ></span>
                </Route>
                <Icon className="w-5 h-5" aria-hidden="true" icon={route.icon} />
                <span className="ml-4">{route.name}</span>
              </NavLink>
            </li>
          ):null
          
        )}
      </ul> 
      </AuthContext.Provider>    
    </div>
  )
}

export default SidebarContent
