class CreatePhones < ActiveRecord::Migration[5.2]
  def change
    create_table :phones do |t|
      t.string :name
      t.float  :price
      t.text   :description
      t.timestamps
    end
  end
end
