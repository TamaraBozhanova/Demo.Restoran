Rails.application.routes.draw do
  get 'items/index'

  root 'items#index'
  #match ':controller(/:action(/:id))(.:format)'
  # For details on the DSL available within this file, see http://guides.rubyonrails.org/routing.html
end
