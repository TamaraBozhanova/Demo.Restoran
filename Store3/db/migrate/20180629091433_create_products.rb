class CreateProducts < ActiveRecord::Migration[5.2]
  def change
    create_table :products do |t|
      t.string :name
      t.float :price
      t.float :weight
      t.text :description

      t.timestamps
    end
  end
end
